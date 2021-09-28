package com.company;

import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;

public class Server {
    // Выбираем порт вне пределов 1–1024:
    public static final int PORT = 8080;


    public static void main() throws IOException{
        ServerSocket s = new ServerSocket(PORT);
        System.out.println("Started: " + s);

        try {
            Socket socket = s.accept();

            try {
                System.out.println("Сервер запущен");
                BufferedReader in = new BufferedReader(new InputStreamReader(socket.getInputStream()));
                PrintWriter out = new PrintWriter(new OutputStreamWriter(socket.getOutputStream()), true);

                while (true) {
                    String str = in.readLine();

                    if (str.equals("END"))
                        break;

                    System.out.println("Echoing: " + str);
                    out.println(str);
                }
                /* Всегда закрываем два сокета...*/
            } finally {
                System.out.println("closing...");
                socket.close();
            }
        } finally {
            s.close();
        }
    }
}
