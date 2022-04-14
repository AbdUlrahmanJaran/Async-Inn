# Explanation
## Hotel
Every Item in this table is a hotel, it has an ID which is a primary key and it has these properties: name, location which is a composite property (city, state, address) and a phone number.

## Room
Every Item in this table is a room, it has an ID which is a primary key, a nickname to descripe it, a price and a type.

## Hotel Rooms
This table contains two foreign keys. it connect every room with a hotel, and has a property called 'number of rooms'.

## Amenitie
Every Item in this table is an amenitie which has a name it could be “air conditioning”, “coffee maker”, “ocean view”, or a “mini bar”.

## Room Amenities
This table contains two foreign keys. it connect every room with its amenities.

## Type
This is an Enum, it has a foreign key for a room and could be one of those: one bedroom, two bedrooms, cozy studio.