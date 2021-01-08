# Big SQL Runner
A small tool that can run HUGE Microsoft SQL Server script files (of several Gigabytes)

![Big SQL Runner Main Screen](https://user-images.githubusercontent.com/17026744/83193020-c4b38400-a10c-11ea-92ff-ab7304f5aa0a.png)

This simple tool solves a very annoying problem of Management Studio: Open HUGE script files.
Microsoft SQL Server Management Studio opens the entire file into memory, and this can be a  problem if your file is bigger than the available memory.

Big SQL Runner solves that by reading the input file line-by-line, hence, not having to deal with memory issues.
Also, Big SQL Runner runs the file in small chuncks of 300 lines each (this number can be adjusted from 1 to 5000 lines). This way each chunck will run fast and it'll allow to track the script execution progress. It also keeps the server running happy if you are not holding any transaction open.

![Running](https://user-images.githubusercontent.com/17026744/83192970-aea5c380-a10c-11ea-9811-d65d838a1833.png)

Main features:
* Can open ANY SIZE of script file
* Runs fast, low memory footprint
* Breaks the script into smaller chuncks
* Tracks script execution progress
* Calculates remaining executing time (based on average execution speed)
* Bypasses errors and saves the error chunck lines into a separated file (same name as the input file, but with ".error" extension).
* Can resume the script execution from a specified line number
* Recognizes "GO" statements. GO will make the chunck execute immediately and start a new chunck after
* It saves the last used connection string on the registry, so next time you open it, the connection string will be there
* It's free and open-source

Instructions:
- Inform the connection string
- Select the script file
- Click "Run Script Now!" button
