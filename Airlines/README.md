Project worked in .Net Core v3.1.0
NuGet package Newtonsoft.Json v13.0.1

The logic is handled in Models.Process.cs
The output is shaped in Models.XmlMill.cs
Program.cs is the driver for the code. Standard console application.

To run have the desired processed json be in a file "airlines.json" in the
Desktop folder. This can easily be changed in the Program.cs file.

The results will be outputted to the terminal. The mapping can easily be found
in the Process.cs as the class has comments to which attributes map to the
answers. The XmlMill.cs can then be seen how those attributes map to the xml.

Areas for enhancements.
Take in command line arguments for the json file.
command line argument for the output whether its as a file or terminal.

Assumptions Made:
flights are not counted twice, once for departure and again on arrival