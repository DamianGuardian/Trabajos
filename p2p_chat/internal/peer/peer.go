package main

import (
    "bufio"
    "fmt"
    "net"
    "os"
    "time"
)

var username string

func StartListening(port string, user string) {
    username = user
    listener, err := net.Listen("tcp", ":"+port)
    if err != nil {
        fmt.Println("Error listening:", err.Error())
        os.Exit(1)
    }
    defer listener.Close()
    fmt.Printf("Peer is listening on port %v ...\n", port)
    for {
        conn, err := listener.Accept()
        if err != nil {
            fmt.Println("Error accepting connections:", err.Error())
            continue
        }
        go handleConnection(conn)
    }
}

func ConnectToPeer(address string, user string) {
    username = user
    for {
        conn, err := net.Dial("tcp", address)
        if err != nil {
            fmt.Println("Error connecting to peer:", err.Error())
            fmt.Println("Attempting to reconnect in 5 seconds...")
            time.Sleep(5 * time.Second)
            continue
        }
        handleConnection(conn)
        break
    }
}

func handleConnection(conn net.Conn) {
    defer conn.Close()
    go receiveMessages(conn)
    sendMessages(conn)
}

func receiveMessages(conn net.Conn) {
    reader := bufio.NewReader(conn)
    for {
        message, err := reader.ReadString('\n')
        if err != nil {
            fmt.Println("Error reading message:", err.Error())
            return // consider reconnect logic here if needed
        }
        fmt.Print("Received: " + message)
    }
}

func sendMessages(conn net.Conn) {
    writer := bufio.NewWriter(conn)
    scanner := bufio.NewScanner(os.Stdin)
    fmt.Println("You can start typing messages... (type 'exit' to quit)")

    for {
        fmt.Print("Type your message: ")
        if scanner.Scan() {
            message := scanner.Text()
            if message == "exit" {
                fmt.Println("Exiting chat...")
                return
            }
            fullMessage := username + ": " + message + "\n"
            if _, err := writer.WriteString(fullMessage); err != nil {
                fmt.Println("Error sending message:", err.Error())
                continue
            }
            if err := writer.Flush(); err != nil {
                fmt.Println("Error flushing writer:", err.Error())
                return
            }
        } else if scanner.Err() != nil {
            fmt.Println("Error reading input:", scanner.Err())
            return
        }
    }
}

func main() {
    // Example usage: Start listening or connect to peer
    go StartListening("8081", "user1")
    ConnectToPeer("localhost:8081", "user2")
}
