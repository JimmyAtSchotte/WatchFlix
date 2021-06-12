# WatchFlix

Run in Visual studio/Rider (requires .net 5.0 installed)
1. Open solution
2. Change TMDB_API_KEY in launchSettings.json (Watchflix/Properties) to your api key
3. Run Watchflix project

Run with docker
1. docker build -t watchflix .
2. docker run -p 127.0.0.1:5001:80/tcp -e "TMDB_API_KEY=YOUR_API_KEY" watchflix
3. Browse to http://127.0.0.1:5001/