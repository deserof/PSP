package lab7;

import java.rmi.AlreadyBoundException;
import java.rmi.RMISecurityManager;
import java.rmi.RemoteException;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;
import java.rmi.server.UnicastRemoteObject;

public class Server {
    public static void main(String[] args) throws RemoteException, AlreadyBoundException {
        System.setProperty( "java.security.policy","D:\\Artem\\Desktop\\psp\\lab7\\lab7\\src\\.java.policy");
        System.setSecurityManager(new RMISecurityManager());

        CardService cardServiceObj = new CardServiceRemote();

        CardService stub = (CardService) UnicastRemoteObject.exportObject(cardServiceObj, 0);
        Registry registry = LocateRegistry.createRegistry(9095);
        registry.bind("CardServiceRemote", stub);
    }
}
