package com.company;

import java.io.*;
import java.net.Socket;
import java.util.ArrayList;

public class EchoThread extends Thread {
    private Socket socket;
    private BufferedReader in;
    private PrintWriter out;
    private String username;
    private ArrayList<Socket> sockets;

    public EchoThread(Socket clientSocket, ArrayList<Socket> sockets) {
        this.socket = clientSocket;

        try {
            in = new BufferedReader(new InputStreamReader(socket.getInputStream()));
            out = new PrintWriter(new OutputStreamWriter(socket.getOutputStream()), true);
        } catch (IOException e) {
            return;
        }

        this.sockets = sockets;
    }

    public void run() {

        try {
            username = in.readLine();
        } catch (IOException e) {
            e.printStackTrace();
        }

        boolean isFirstMessage = true;
        boolean isLastMessage = false;

        while (true) {
            try {
                String text = in.readLine();

                System.out.println("ServerLogInfo: " + username + ": " + text);

                for (Socket socket:sockets) {
                  PrintWriter bc = new PrintWriter(new OutputStreamWriter(socket.getOutputStream()));

                    if(isFirstMessage){
                        text = "вошел в чат";
                    }

                    isFirstMessage = false;

                    if (text.equals("quit")){
                        text = "вышел из чата";
                        isLastMessage = true;
                        bc.println(username + ": " + text);
                        bc.flush();
                        break;
                    }

                  bc.println(username + ": " + text);
                  bc.flush();
                }

                if(isLastMessage){
                    socket.close();
                    return;
                }

            } catch (IOException e) {
                out.println(username + " вышел");
                System.out.println("disconnected");
                return;
            }
        }
    }
}
