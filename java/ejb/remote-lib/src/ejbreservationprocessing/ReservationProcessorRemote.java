/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ejbreservationprocessing;

import java.util.List;
import javax.ejb.Remote;

/**
 *
 * @author owner
 */
@Remote
public interface ReservationProcessorRemote {
    public List<String> listCustomers();
    public List<String> listReservations (int cid);
    public List<String> listAvailable (String in, String out);
    public double book (int cid, int rid, String in, String out);
    
}
