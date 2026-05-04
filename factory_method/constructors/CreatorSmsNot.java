package constructors;

import models.Notification;
import models.SmsNotification;

public class CreatorSmsNot extends Creator{

    @Override
    public Notification createNotification() {
        return new SmsNotification();
    }
    
}
