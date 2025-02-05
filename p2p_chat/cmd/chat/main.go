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
	clients   = make(map[net.Conn]bool) // Mapa de clientes conectados
	clientsMu sync.Mutex                // Mutex para controlar el acceso a la lista de clientes
)

func broadcastMessage(msg string, sender net.Conn) {
	clientsMu.Lock()
	defer clientsMu.Unlock()
	for conn := range clients {
		if conn != sender { // Enviar el mensaje a todos excepto al emisor
			fmt.Fprintf(conn, msg)
		}
	}
}

func handleConnection(conn net.Conn, username string) {
	defer conn.Close()
	clientsMu.Lock()
	clients[conn] = true
	clientsMu.Unlock()

	fmt.Printf("[%s] Connected to peer\n", username)
	scanner := bufio.NewScanner(conn)
	for scanner.Scan() {
		text := scanner.Text()
		fmt.Printf("[%s] Received: %s\n", username, text)
		message := fmt.Sprintf("[%s] %s\n", username, text)
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
		peer.ConnectToPeer("localhost:" + port, username) // Adjust as needed
	} else {
		startServer(port, username)
	}
}