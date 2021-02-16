# SteelDaily

https://dailysteel.joeovertonmusic.com/ 

Thanks for stopping by!

SteelDaily aka DailySteel aka SteelHead is a educational app for pedal steel guitarists, featuring dynamic server-side modeling of the steel guitar neck and interval relationships relative to a user's selected key.

TO RUN THIS APP LOCALLY

1. pull down the repo
2. run both the SQL statments in the SQL directory
3. create a Firebase project.

	-Go to Firebase and add a new project. You can name it whatever you want (SteelDaily is a good name)
	-Go to the Authentication tab, click "Get Started", then click "Set up sign in method", and enable the Username and Password option.
	-Add at least two new users in firebase. Use email addresses that you find in the UserProfile table of your SQL Server database
	-Once firebase creates a UID for these users, copy the UID from firebase and update the FirebaseUserId column for the same users in your SQL Server database.
	-Click the Gear icon in the sidebar to go to Project Settings. You'll need the information on this page for the next few steps

4. open appsettings.json and change the "FirebaseProjectId" to the "Project ID" in your Firebase project settings
5. Open your client directory in VsCode. Open the .env.local.example file. Replace __YOUR_API_KEY_HERE__ with your own firebase Web API Key
6. Rename the .env.local.example file to remove the .example extension. This file should now just be called .env.local
7. Install your dependencies by running npm install from the same directory as your package.json file
8. run the client side app with `npm start` in your client directory
