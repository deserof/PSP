package lab7;

import java.net.MalformedURLException;
import java.rmi.NotBoundException;
import java.rmi.RMISecurityManager;
import java.rmi.RemoteException;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;
import java.util.Scanner;

public class Client {

    public static void main(String[] args) throws RemoteException, NotBoundException, MalformedURLException {
        System.setProperty("java.security.policy", "D:\\Artem\\Desktop\\psp\\lab7\\lab7\\src\\.java.policy");
        System.setSecurityManager(new RMISecurityManager());

        Registry registry = LocateRegistry.getRegistry("127.0.0.1", 9095);
        CardService cardService = (CardService) registry.lookup("CardServiceRemote");

        Scanner sc = new Scanner(System.in);
        String cardNumber = null;
        String cardPin = null;

        System.out.print("1. Add new card \n");
        System.out.print("2. Use existed card \n");
        System.out.print("Enter menu number\n");
        int menu = sc.nextInt();
        switch (menu) {
            case 1: {
                System.out.print("Enter card number\n");
                sc.nextLine();
                cardNumber = sc.nextLine();
                System.out.print("Enter card pin\n");
                cardPin = sc.nextLine();

                if (cardService.createCard(cardNumber, cardPin)) {
                    System.out.print("Successful\n");
                } else {
                    System.out.print("Card is existed\n");
                    return;
                }
                break;
            }
            case 2: {
                System.out.print("Enter card number\n");
                sc.nextLine();
                cardNumber = sc.nextLine();
                System.out.print("Enter card pin\n");
                cardPin = sc.nextLine();

                if (cardService.isCardCorrect(cardNumber, cardPin)) {
                    System.out.print("Successful login\n");
                } else {
                    System.out.print("Invalid credentials\n");
                    return;
                }
                break;
            }
        }

        Boolean isWork = true;
        while (isWork) {
            System.out.print("1. Add money\n");
            System.out.print("2. Withdraw money\n");
            System.out.print("3. Show card info \n");
            System.out.print("4. Exit \n");
            System.out.print("Enter menu number\n");
            menu = sc.nextInt();

            switch (menu) {
                case 1: {
                    System.out.print("Enter money that you want to add\n");
                    cardService.addMoney(cardNumber, sc.nextInt());
                    break;
                }
                case 2: {
                    System.out.print("Enter money that you want to withdraw\n");
                    cardService.withdrawMoney(cardNumber, sc.nextInt());
                    break;
                }
                case 3: {
                    System.out.print(cardService.showInfo(cardNumber) + "\n");
                    break;
                }
                case 4: {
                    isWork = false;
                    break;
                }
            }
        }
    }
}
