package lab7;

import java.util.ArrayList;

public class Storage {
    public static ArrayList<Card> cards = new ArrayList<Card>() {
        {
            add(new Card("1111", "1111", 0));
            add(new Card("2222", "1234", 200));
            add(new Card("3333", "0000", 100));
        }
    };
}
