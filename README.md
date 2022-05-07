# Project name: Async-Inn
## This done by AbdUlrahman Jaran

## API server for a Hotel Asset Management system.

![AsyncInnERD.png](./images/AsyncInnERD.png) <br>

## [Explanation](./Explanation.md)

## Architecture Pattern
This API use Dependency Injection.
Dependency Injection (DI) is a design pattern allows the creation of dependent objects outside of a class and provides those objects to a class through different ways. Using DI, we move the creation and binding of the dependent objects outside of the class that depends on them.

## End Points
### GET a Hotel by Id: /api/Hotels/1<br>
![Hotels/1](./images/Hotels-1.png)

### GET a Room: /api/Rooms/1<br>
![Rooms/1](./images/Rooms-1.png)

#### after DTO
```JSON
{
    "id": 1,
    "name": "FirstStudio",
    "layout": 0,
    "amenities": [
        {
            "id": 1,
            "name": "FirstStudio"
        }
    ]
}
```

### GET an Amenity: /api/Amenities/1<br>
![Amenities/1](./images/Amenities-1.png)


#### after DTO
```JSON
{
    "id": 1,
    "name": "Coffee Machine"
}
```
### GET all the rooms for a hotel: /api/HotelRooms/{hotelId}/Rooms
```JSON
[
    {
        "hotelID": 1,
        "roomID": 1,
        "roomNumber": 1,
        "rate": 1.00,
        "petFriendly": 0,
        "hotel": {
            "id": 1,
            "name": "AsyncInn Amman",
            "streetAddress": "St1-2",
            "city": "Amman",
            "state": "",
            "country": "Jordan",
            "phone": "+962775777777",
            "hotelRooms": []
        },
        "room": {
            "id": 1,
            "name": "FirstStudio",
            "layout": 0,
            "roomAmenities": [
                {
                    "amenityID": 1,
                    "roomID": 1,
                    "amenity": {
                        "id": 1,
                        "name": "Coffee Machine",
                        "roomAmenities": []
                    }
                }
            ],
            "hotelRooms": []
        }
    }
]
```

### GET all room details for a specific room: /api/HotelRooms/{hotelId}/Rooms/{roomNumber}
```JSON
{
    "hotelID": 1,
    "roomID": 1,
    "roomNumber": 1,
    "rate": 1.00,
    "petFriendly": 0,
    "hotel": {
        "id": 1,
        "name": "AsyncInn Amman",
        "streetAddress": "St1-2",
        "city": "Amman",
        "state": "",
        "country": "Jordan",
        "phone": "+962775777777",
        "hotelRooms": []
    },
    "room": {
        "id": 1,
        "name": "FirstStudio",
        "layout": 0,
        "roomAmenities": [
            {
                "amenityID": 1,
                "roomID": 1,
                "amenity": {
                    "id": 1,
                    "name": "Coffee Machine",
                    "roomAmenities": []
                }
            }
        ],
        "hotelRooms": []
    }
}
```

#### after DTO
```JSON
{
    "hotelID": 1,
    "roomNumber": 1,
    "rate": 1.00,
    "petFriendly": false,
    "roomID": 1,
    "room": {
        "id": 1,
        "name": "FirstStudio",
        "layout": 0,
        "amenities": [
            {
                "id": 1,
                "name": "Coffee Machine"
            }
        ]
    }
}
```

### GET all the Amenities: /api/Amenities
#### after DTO
```JSON
[
    {
        "id": 1,
        "name": "Coffee Machine"
    },
    {
        "id": 2,
        "name": "Air Conditioner"
    },
    {
        "id": 3,
        "name": "Sea View"
    }
]
```

### GET all the Hotels: /api/Hotels

### GET all the rooms: /api/Rooms

### POST to add a room to a hotel: /api/HotelRooms/{hotelId}/Rooms

### PUT update the details of a specific room: /api/HotelRooms/{hotelId}/Rooms/{roomNumber}

### DELETE a specific room from a hotel: /api/HotelRooms/{hotelId}/Rooms/{roomNumber}