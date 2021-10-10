package lab7;

import java.io.Serializable;

public class Card implements Serializable {
    private String number;
    private String pinCode;
    private int balance;

    public Card(String number, String pinCode, int balance){
        this.number = number;
        this.pinCode = pinCode;
        this.balance = balance;
    }

    public void setNumber(String number){
        this.number = number;
    }

    public void setPinCode(String pinCode){
        this.pinCode = pinCode;
    }

    public void setBalance(int balance){
        this.balance = balance;
    }

    public String getNumber(){
        return this.number;
    }

    public String getPinCode(){
        return this.pinCode;
    }

    public int getBalance(){
        return this.balance;
    }
}
