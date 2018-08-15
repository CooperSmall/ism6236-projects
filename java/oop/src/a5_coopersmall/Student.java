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
public class Student {
    
    private int studentID;
    private String studentName;
    private double examScore;
    private double projectScore;
    
    public Student() {
        
        this.studentID = -100;
        this.studentName = "n/a";
        this.examScore = 0.0;
        this.projectScore = 0.0;
    }
    
    public Student(String studentName, int studentID) {
        
        this.studentName = studentName;
        this.studentID = studentID;
    }
    
    public double getExamScore() {return examScore;}
    public void setExamScore (double exam) {
        if (exam <= 100 && exam > 0) this.examScore = exam;
    }
    
    public double getProjectScore() {return projectScore;}
    public void setProjectScore (double project) {
        if (project <= 150 && project >0)  this.projectScore = project;
    }
    
    public double computeTotalScore() {
        
        double totalScore = (examScore*(60.0/100.0)) + (projectScore*(40.0/150.0));
        return totalScore;
    }
    
    public char computeGrade() {
        
        double totalScore = computeTotalScore();
        char grade;
        
        if (totalScore >= 90) grade = 'A';
        else if (totalScore < 90 && totalScore >= 80) grade = 'B';
        else grade = 'C';
        
        return grade;
    }
    
    public String toString() {
        
        double totalScore = computeTotalScore();
        char grade = computeGrade();
        
        return String.format ("%-8d%-8s%-12f%-12f%-12f%-12c\n",
                studentID, studentName, examScore, projectScore,
                totalScore, grade);
        
    }
    
    
    
    
    
}
