package com.company;

import javax.imageio.IIOException;
import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

public class Main {

    private static int port = 8081;
    private static ServerSocket serverSocket;
    private static Socket socket;

    public static void main(String[] args) {
        try {
            serverSocket = new ServerSocket(port);
        } catch (IOException e) {
            e.printStackTrace();
        }

        while (true) {
            try {
                socket = serverSocket.accept();
            } catch (IOException e) {
                System.out.println("error: " + e);
            }

            new EchoThread(socket).start();
        }
    }
}