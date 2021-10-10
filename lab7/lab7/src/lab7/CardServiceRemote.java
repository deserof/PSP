package lab7;

import java.rmi.RemoteException;

public class CardServiceRemote  implements CardService{
    @Override
    public void addMoney(String cardNumber, int money) throws RemoteException {
        Card card = getCard(cardNumber);

        if(card == null){
            return;
        }

        card.setBalance(card.getBalance() + money);
    }

    @Override
    public void withdrawMoney(String cardNumber, int money) throws RemoteException {
        Card card = getCard(cardNumber);

        if(card == null){
            return;
        }

        card.setBalance(card.getBalance() - money);
    }

    @Override
    public String showInfo(String cardNumber) throws RemoteException {
        Card card = getCard(cardNumber);

        if(card == null){
            return "Card is null\n";
        }

        return "Card number: " + card.getNumber() + ", balance: " + card.getBalance();
    }

    @Override
    public Boolean isCardCorrect(String cardNumber, String cardPin) throws RemoteException {
        for (Card card:Storage.cards) {
            if (card.getNumber().equals(cardNumber) && card.getPinCode().equals(cardPin)){
               return true;
            }
        }

        return false;
    }

    @Override
    public Boolean createCard(String cardNumber, String cardPin) throws RemoteException {
        for (Card card: Storage.cards) {
            if (card.getNumber().equals(cardNumber)) {
                return false;
            }
        }

        Storage.cards.add(new Card(cardNumber, cardPin, 0));

        return true;
    }

    private Card getCard(String cardNumber){
        for (Card card:Storage.cards) {
            if(card.getNumber().equals(cardNumber)){
                return card;
            }
        }

        return null;
    }
}
