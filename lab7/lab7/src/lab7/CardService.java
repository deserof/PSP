package lab7;

import java.rmi.Remote;
import java.rmi.RemoteException;

public interface CardService extends Remote {
    public void addMoney(String cardNumber, int money) throws RemoteException;
    public void withdrawMoney(String cardNumber, int money) throws RemoteException;
    public String showInfo(String cardNumber) throws RemoteException;
    public Boolean isCardCorrect(String cardNumber, String cardPin) throws RemoteException;
    public Boolean createCard(String cardNumber, String cardPin) throws RemoteException;
}
