package models;
public class EmailNotification implements Notification{
    @Override
    public void notifies() {
        System.out.println("Enviando notificação via email....");
    }
}
