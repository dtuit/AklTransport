#AklTransport - Auckland Transport Api CSharp Client

AklTransport is a C# library for accessing the [Auckland Transport Api](https://dev-portal.at.govt.nz/)
uses RestSharp to perform all requests.

###Endpoints

* Realtime GTFS
* Static GTFS
* Display Data

###Install

**nuget** : 

##How to Use
You will need an API key. You can get one [here](https://dev-portal.at.govt.nz/)

####Static GTFS and Display Data
```c#
    var GtfsClient = new ATGtfsClient("API_KEY");

    //Example Calls
    TripResponse trips = await GtfsClient.ListTripsAsync();
    TripResponse trips2 = await GtfsClient.GetTripsByRouteIdAsync("ROUTE_ID")
    
    foreach(Trip trip in trips.Response){
        // ...
    }
    
```

####RealTime GTFS

```c#
    var RealTimeClient = new ATRealTimeClient("API_KEY");
    
    //Example Calls
    FeedMessage realTimeFeed = await RealTimeClient.GetGTFSRealTimeFeed();
```

###Dependencies 

[RestSharp](https://github.com/restsharp/RestSharp)
[ProtoBuf-net](https://github.com/mgravell/protobuf-net)