import java.util.Scanner;

import constructors.*;
import models.*;

public class Main{
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Creator creator;

        String option;
        do{
            System.out.println("Qual tipo de notificação você deseja?\nM = Email\nS = Sms");
            option = scanner.next();

        } while(option.toUpperCase() != "M" || option.toUpperCase() != "S");

        if (option.toUpperCase() == "M"){
            creator = new CreatorEmailNot();
        }
        else{
            creator = new CreatorSmsNot();
        }

        Notification notification = creator.createNotification();

        /*
        Utilizando a factory
        notification = NotifyFactory.create(option);
        */

        System.out.println("====================================");
        notification.notifies();
        System.out.println("====================================");
        
        scanner.close();
    }
}