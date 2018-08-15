Assignment 2 Instructions
_________________________

1) Add all 4 files to a directory of your choice
2) Load "smalldblib" into Netbeans 
3) Right Click "smalldblib" and Select "Build" to compile
4) Load "smallcasg2RemoteLib1" into Netbeans
5) Right Click "smallcasg2RemoteLib1" and Select "Build" to compile
6) Select the "Services" tab on the left side
7) Load "smallcasg2EJB1" into Netbeans
8) Right click the "Libraries" directory select "Add Jar" and load the "smalldblib.jar" from the "smalldblib" dist file using relative pathways
9) Right click the "Libraries" directory select "Add Project" and add the "smallcasg2RemoreLib1" project
10) Select "Servers" the right click "Glassfish" and select "Start"
11) Add the Microsoft JBDC drivers to programfiles/gassfish-4.1.1/glassfish/lib
12) Right Click "smallcasg2EJB1" and Select "Build" to compile
13) Load "smallcasg2client" into Netbeans and Select "Build" to compile
14) Right click the "Libraries" directory select "Add Jar" and load the "smallcasg2RemoteLib1.jar" from the smallcasg2RemoteLib1 dist file using relative pathways
15) Right click the "Libraries" directory select "Add Jar" and load the "appserv-rt.jar" from programfiles/gassfish-4.1.1/glassfish/lib
16) Right Click "smallcasg2client" and Select "Build" to compile
17) Right Click "smallcasg2client" and Select "Run" and the project should load

!!!Project Notes!!!
___________________

While the book method works correctly in the original library, the EJB client errors and returns a value of 0. Glassfish returns an error of "cannot envoke 
rollback operaton while AutoCommit is set to 'True'", even though I have set this parameter in multiple locations. After rewriting my code several timess with 
this in mind, I've come to believe this is an error with Glassfish translating this operation; when I loaded my library into Assignment 1's local client, the 
commit worked as expected. You can test my book method by loading the JBDC drivers into the library project and running the call I wrote in the main method.