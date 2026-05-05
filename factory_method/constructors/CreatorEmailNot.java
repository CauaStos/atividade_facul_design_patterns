package constructors;

import models.EmailNotification;
import models.Notification;

public class CreatorEmailNot extends Creator {

    @Override
    public Notification createNotification() {
        return new EmailNotification();
    }
}
