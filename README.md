VentuzLoadSaveXML
=================

This is a Ventuz3 C# script that loads/saves strings from/to XML files. 

### edit the custom model accordingly:

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
| string      | loadedText |


### connect a string array to the script node:


![alt text](Http://sebastianspiegl.de/VentuzLoadSaveXML_connection.png "VentuzLoadSaveXML_connection.png")

### troubleshooting:

|Error    | Solution |
|---------|-----|
|Check method Onload in Script Node Script... File "filename" could not be found |Either create your initial XML file manually OR invoke **_save_** first to create it from inside Ventuz.|
|Check method Onsave in Script Node Script... Access to path "filename" is denied|You haven't got the privilege to write to the path you provided. Use "C:\Users\ **_accountName_** \..." instead. |












