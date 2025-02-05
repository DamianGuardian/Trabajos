package main

import (
    "bufio"
    "fmt"
    "net"
    "os"
    "sync"

    "github.com/DamianGuardian/p2p_chat/internal/peer"
)

var (
    clients   = make(map[net.Conn]bool) 
    clientsMu sync.Mutex                
)


func broadcastMessage(msg string, sender net.Conn) {
    clientsMu.Lock()
    defer clientsMu.Unlock()
    for conn := range clients {
        fmt.Fprintf(conn, msg)
    }
}


func handleConnection(conn net.Conn, username string) {
    defer conn.Close()
    clientsMu.Lock()
    clients[conn] = true
    clientsMu.Unlock()

    welcomeMessage := fmt.Sprintf("[%s] Connected to server\n", username)
    fmt.Print(welcomeMessage) 
    fmt.Fprintf(conn, welcomeMessage) 

    scanner := bufio.NewScanner(conn)
    for scanner.Scan() {
        text := scanner.Text()
        message := fmt.Sprintf("[%s] %s\n", username, text)
        fmt.Print(message) 
        broadcastMessage(message, conn) 
    }

    clientsMu.Lock()
    delete(clients, conn)
    clientsMu.Unlock()

    if err := scanner.Err(); err != nil {
        fmt.Printf("[%s] Error: %s\n", username, err)
    }
}


func startServer(port, username string) {
    listener, err := net.Listen("tcp", ":"+port)
    if err != nil {
        fmt.Println("Error listening:", err.Error())
        os.Exit(1)
    }
    defer listener.Close()
    fmt.Printf("[%s] Server is listening on %s...\n", username, port)

    for {
        conn, err := listener.Accept()
        if err != nil {
            fmt.Println("Error accepting: ", err.Error())
            os.Exit(1)
        }
        go handleConnection(conn, username)
    }
}


func main() {
    if len(os.Args) != 4 {
        fmt.Println("Usage: <operation> <port> <username>")
        os.Exit(1)
    }

    operation := os.Args[1]
    port := os.Args[2]
    username := os.Args[3]

    if operation == "connect" {
        peer.ConnectToPeer("localhost:" + port, username) 
    } else {
        startServer(port, username)
    }
}
