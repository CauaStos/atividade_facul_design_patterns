package constructors;

import models.*;

public class NotifyFactory {
    /*
        É possível fazer dessa forma mais simples,
        porém não esta seguindo o factory method estritamente 
    */
    public static Notification create(String type){
        if (type.toLowerCase().equals("email")){
            return new EmailNotification();
        }
        if (type.toLowerCase().equals("sms")){
            return new SmsNotification();
        }
        return null;
    }
}
