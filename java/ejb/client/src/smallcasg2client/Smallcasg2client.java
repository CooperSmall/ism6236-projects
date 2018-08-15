/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package smallcasg2client;

import java.io.PrintStream;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

import javax.naming.InitialContext;
import java.rmi.RemoteException;
import ejbreservationprocessing.ReservationProcessorRemote;

/**
 *
 * @author owner
 */
public class Smallcasg2client {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        
        ReservationProcessorRemote db = null;
        
        try {
            InitialContext c = new InitialContext();
             db = (ReservationProcessorRemote)c.lookup("java:global/smallcasg2EJB1/ReservationProcessor");

        } 
        catch (Exception e) {
            e.printStackTrace();
        }
        
        PrintStream out = System.out;
        Scanner in = new Scanner(System.in);

        
        List<String> cust = new ArrayList (db.listCustomers());
        for (int i=0; i < cust.size(); i++){
            out.println(cust.get(i));
            out.flush();}
        
        out.println("Enter 'L' to list customer's reservations, 'B' to book a reservation,  or 'Q to quit");
        out.flush();
        String input = in.nextLine();
        
        boolean quit = false;
        while(!quit) {
            int r = input.charAt(0);
            if (r == 'l' || r== 'L') {
                    out.println("Enter Customer ID: ");
                    out.flush();
                    String id = in.nextLine();
                    int cid = Integer.parseInt(id);
                    List<String> temp = new ArrayList (db.listReservations(cid));
                    for (int i=0; i<temp.size(); i++) {
                        String row = temp.get(i);
                        String print = String.format(" Reservation: %s", row);
                        out.println(print);
                        out.flush();}}
                    
            else if (r == 'b' || r== 'B') {
                    out.println("Date-In (mm/dd/yy): ");
                    out.flush();
                    String din0 = null;
                    String din = null;
                    while (din == null) {
                        din0 = in.nextLine();
                        int counter = 0;
                        String[] format = din0.split("/");
                        for (int i=0; i<format.length; i++) {
                            if (format[i].length()==2 || format[i].length()==1){
                            counter++;}
                            else break;}
                        if (counter==3){
                        int m = Integer.parseInt(format[0]);
                        int d = Integer.parseInt(format[1]);
                        int y = Integer.parseInt(format[2]);
                        y += 2000;
                        din = (y + "-" + m + "-" + d); break;}
                        else out.println("Please Re-Enter Date (mm/dd/yy): "); }
                    out.println("Date-Out (mm/dd/yy): ");
                    out.flush();
                    String dout0 = null;
                    String dout = null;
                    while (dout == null) {
                        dout0 = in.nextLine();
                        int counter = 0;
                        String[] format = dout0.split("/");
                        for (int i=0; i<format.length; i++) {
                            if (format[i].length()==2 || format[i].length()==1){
                            counter++;}
                            else break;}
                        if (counter==3){
                        int m = Integer.parseInt(format[0]);
                        int d = Integer.parseInt(format[1]);
                        int y = Integer.parseInt(format[2]);
                        y += 2000;
                        dout = (y + "-" + m + "-" + d); break;}
                        else out.println("Please Re-Enter Date (mm/dd/yy): "); }
                    List<String> temp1 = new ArrayList(db.listAvailable(din,dout));
                    if (temp1.size()>1){
                    for (int i=0; i<temp1.size(); i++) {
                        String row = temp1.get(i);
                        String print = String.format(" Available: %s", row);
                        out.println(print);
                        out.flush();}
                    out.println("Enter 'b' to book or 'c' to cancel");
                    out.flush();
                    String next = in.nextLine();
                    int e = next.charAt(0);
                    
                    switch (e) {
                        case 'b':
                        case 'B':
                            out.println("Enter Customer ID: ");
                            out.flush();
                            String id1 = in.nextLine();
                            int cid1 = Integer.parseInt(id1);
                            out.println("Enter Room Number: ");
                            out.flush();
                            int rid = 0;
                            String test = null;
                            while (true) {
                                String id2 = in.nextLine();
                                int id = Integer.parseInt(id2);
                                for (int i=0; i<temp1.size(); i++) {
                                    test = temp1.get(i);
                                    String[] temp = (test.split(","));
                                    int check = Integer.parseInt(temp[0]);
                                    if (id == check) {rid = id; break;} }
                                if (rid == 0) {out.println("Please Enter an Available Room's Number: ");}
                                else{
                                    double price = db.book(cid1,rid,din,dout);
                                    String print = String.format("The Total Cost of Your Reservation is: %f", price);
                                    out.flush();
                                    out.println(print); 
                                    break;}}
                        break;
                        case 'c':
                        case 'C':
                        break; 
                        default: break;}}
                    
            else out.println(temp1.get(0));}
            
            else quit = true;
                
                if (!quit) {
                    out.println("Enter 'L' to list customer's reservations, 'B' to book a reservation,  or 'Q to quit");
                    out.flush();
                    input = in.nextLine(); }       
            }
        }
    }
    
