VentuzLoadSaveXML
=================
Wouldn't it be cool if Ventuz could save data directly to an XML file? Here is a solution, a C# script that saves data into and loads it form an XML file. This C# script is easily extendible to work with integers and floats as well.

But before you start hacking in the code, you have to edit the "custom model" of your freshly generated C# script node. 

#### Create the following inputs & outputs:

##### inputs

| type          | name          |
| ------------- |-------------|
| string      | fileName |
| method     | load      |
| method | save      |
| string array | textToSave      |

##### outputs

| type          | name          |
| ------------- |-------------|
| string array | loadedText |


#### connect a string array to the script node:


![alt text](Http://sebastianspiegl.de/VentuzLoadSaveXML_connection.png "VentuzLoadSaveXML_connection.png")

#### troubleshooting:

|Error    | Solution |
|---------|-----|
|Check method Onload in Script Node Script... File "filename" could not be found |Either create your initial XML file manually OR invoke **_save_** first to create it from inside Ventuz.|
|Check method Onsave in Script Node Script... Access to path "filename" is denied|You haven't got the privilege to write to the path you provided. Use "C:\Users\ **_accountName_** \..." instead. |












