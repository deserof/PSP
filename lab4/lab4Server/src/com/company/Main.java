package com.company;

import javax.imageio.IIOException;
import java.io.IOException;

public class Main {

    public static void main(String[] args) {
        System.out.println("dfsdfsdfdf");

        try{
            Server.main();
        }
        catch (IOException ex){
            System.out.println(ex.getMessage());
        }
    }
}