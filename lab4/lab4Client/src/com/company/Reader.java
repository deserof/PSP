package com.company;

import java.io.*;
import java.net.Socket;

public class Reader extends Thread{
    private Socket socket;
    private BufferedReader in;

    public Reader(Socket clientSocket) {
        this.socket = clientSocket;
        try {
            in = new BufferedReader(new InputStreamReader(socket.getInputStream()));
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void run(){
        while(true){
            try {
                String serverWord = in.readLine();
                System.out.println(serverWord);
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
}
