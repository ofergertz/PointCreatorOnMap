# PointCreatorOnMap
A system to create point with X,Y coordinates and show them on map of different application (Blazor WASM app and blazor server app)
One application is EntitiesCreatorApp that creates the points and send them to other applications via hub connection and show them on map
![image](https://user-images.githubusercontent.com/35465069/204540704-e3d0452d-db94-43dd-a876-a434b861ab99.png)
![image](https://user-images.githubusercontent.com/35465069/204541211-82d9373a-a6ff-44ec-bc84-c55c50e4d11e.png)
the floating button is to delete all points


By using the hub we are simply can add other application (can be WPF or anything else) to get messages from hub and show the points on their on clients
On the top right corner of the point creator application, you have a link to my own personal github account.


#Configuration
In the point creator app, we have appsettings.json file:
![image](https://user-images.githubusercontent.com/35465069/204545207-f15113a9-8281-427e-9ca0-dc069cd90b34.png)

there we can change the hub url to which we want to connect and the background image path we want to load from the image.

In the points presenter app we also have appsettings.json file there we can modify:
- the svg (graphic component) width and height by your screen resulotion.
- the world map path (or any other image)
- the Y radius of our ellipse shape we are creating
- cache key where all the points we are creating saved
![image](https://user-images.githubusercontent.com/35465069/204545607-d0b972a3-23b8-4456-87c1-db6d18a0c108.png)

