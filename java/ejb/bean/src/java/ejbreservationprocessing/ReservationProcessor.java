/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ejbreservationprocessing;

import javax.ejb.Stateless;

import javax.ejb.Stateless;
import java.util.List;
import smalldblib.Reservation;
/**
 *
 * @author owner
 */
@Stateless
public class ReservationProcessor implements ejbreservationprocessing.ReservationProcessorRemote {

    Reservation r;
    
    public ReservationProcessor (){
        
        r = new Reservation ();
    }
    
    @Override
    public List<String> listCustomers(){
        return r.listCustomers();
    }
    
    @Override
    public List<String> listReservations (int cid){
        return r.listReservations(cid);
    }
    
    @Override
    public List<String> listAvailable (String in, String out){
        return r.listAvailable(in, out);
    }
    
    @Override
    public double book (int cid, int rid, String in, String out){
        return r.book(cid, rid, in, out);
    }
}
