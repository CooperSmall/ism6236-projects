/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package a5_coopersmall;

/**
 *
 * @author coopersmall
 */
public class A5_cooperSmall {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        
        
        Student fred = new Student("Fred", 1001);
        Student bob = new Student("Bob", 1002);
        Student jill = new Student("Jill", 1003);
        
        fred.setExamScore(95.5);
        bob.setExamScore(85);
        jill.setExamScore(75.5);
        
        fred.setProjectScore(140.5);
        bob.setProjectScore(135.5);
        jill.setProjectScore(120);
        
        
        System.out.printf("%-8s%-8s%-12s%-12s%-12s%-12s\n",
                "ID", "Name", "Exam", "Project", "Total", "Grade");
        
        System.out.print(fred.toString());
        System.out.print(bob.toString());
        System.out.print(jill.toString());
        
        double average = computeAverage(fred, bob, jill);
        double max = computeMax(fred, bob, jill);
        
        System.out.println("\nAverage Total Score = " + average);
        System.out.println("Maximum Total Score = " + max);
      
        
    }
    
    public static double computeAverage(Student fred, Student bob, Student jill) {
        
        double total1 = fred.computeTotalScore();
        double total2 = bob.computeTotalScore();
        double total3 = jill.computeTotalScore();
        
        double average = (total1 + total2 + total3)/3;
        return average;
    }
    
    public static double computeMax(Student fred, Student bob, Student jill) {
        
        double total1 = fred.computeTotalScore();
        double total2 = bob.computeTotalScore();
        double total3 = jill.computeTotalScore();
        
        double max;
        
        if (total1 > total2 && total1 > total3) max = total1;
        else if (total2 > total1 && total2 > total3) max = total2;
        else max = total3;
        
        return max;
    }
    
}
