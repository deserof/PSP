package com.company;

import java.io.IOException;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.net.Socket;

public class Status extends Thread{
    private Socket socket;
    private PrintWriter out;

    public Status(Socket clientSocket) {
        this.socket = clientSocket;
        try {
            out = new PrintWriter(new OutputStreamWriter(socket.getOutputStream()), true);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void run(){
        while(true){
            try {
                Thread.sleep(30000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
            out.println("Your status is online");
        }
    }
}
