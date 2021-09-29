package com.company;

import java.io.*;
import java.net.Socket;

public class EchoThread extends Thread {
    private Socket socket;
    private BufferedReader in;
    private PrintWriter out;
    private String username;
    private Status status;

    public EchoThread(Socket clientSocket) {
        this.socket = clientSocket;

        try {
            in = new BufferedReader(new InputStreamReader(socket.getInputStream()));
            out = new PrintWriter(new OutputStreamWriter(socket.getOutputStream()), true);
        } catch (IOException e) {
            return;
        }

        status = new Status(clientSocket);
    }

    public void run() {

        try {
            username = in.readLine();
            out.println(username + " в чате");
        } catch (IOException e) {
            e.printStackTrace();
        }

        new Thread(new Status(socket)).start();

        while (true) {
            try {
                String text = in.readLine();

                if (text.equals("quit")) {
                    socket.close();
                    return;
                }

                System.out.println("Echoing: " + text);
                out.println(text);
            } catch (IOException e) {
                out.println(username + " вышел");
                System.out.println("disconnected");
                return;
            }
        }
    }

    private void SendStatus() throws InterruptedException {
        Thread.sleep(5000);
        out.println("Вы онлайн");
    }
}
