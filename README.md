Project should run without much setup other than cloning from Git.

Make sure authkeys.txt get is generated from Startup.cs when you run project.
This will be done each time project is run at the moment, and thus will not 
persist used keys from one launch to another. This should be outcommented if
persistence is wanted.

The solution is a web-based solution in a very simple form, without much 
attention paid to layout, since the functional elements have been 
prioritized over fancy looks. Data persistence is acquired through simple
.txt file implementation, all located in the root of the project and 
generated as program runs through the code responsible for this.
