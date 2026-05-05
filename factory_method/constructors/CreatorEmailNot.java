package constructors;

import models.EmailNotification;
import models.Notification;

public class CreatorEmailNot extends Creator {

    @Override
    public Notification createNotification() {
        System.out.println("oi");
        return new EmailNotification();
    }
}
