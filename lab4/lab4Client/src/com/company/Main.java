package com.company;

import java.io.*;
import java.net.Socket;

public class Main {
    private static Socket socket;
    private static BufferedReader reader;
    private static BufferedReader in;
    private static BufferedWriter out;

    public static void main(String[] args) throws IOException {
        socket = new Socket("0.0.0.0", 8080);
        System.out.println("Соединение установлено:");

        reader = new BufferedReader(new InputStreamReader(System.in));
        in = new BufferedReader(new InputStreamReader(socket.getInputStream()));
        out = new BufferedWriter(new OutputStreamWriter(socket.getOutputStream()));

        while(socket.isConnected()){
            System.out.println("->");
            String word = reader.readLine();
            out.write(word + "\n");
            out.flush();
            String serverWord = in.readLine();
            System.out.println(serverWord);
        }
    }
}
