# API-Endpoints

This is a list of the *REST-API* endpoints defined in this project. This file also serves as a record of the already implemented ones and the ones remaining. All the *API* endpoints have the `/api/` prefix in their URL.

## Auth

1. ❎ **POST** ->  `/auth/register`

2. ❎ **POST** ->  `/auth/login`

3. ❎ **POST** ->  `/auth/logout`

4. ❎ **DELETE** ->  `/auth/delete-account/{userId}`

5. ❎ **POST** ->  `/auth/reset-password/{userId}`

6. ❎ **POST** ->  `/auth/change-password/{userId}`

7. ❎ **PUT** ->  `/auth/update-account/{userId}`

## Admin

1. ❎ **POST** -> `/admin/create-card`

2. ❎ **PUT** -> `/admin/update-card/{cardId}`

3. ❎ **DELETE** -> `/admin/delete-card/{cardId}`

4. ❎ **POST** -> `/admin/create-clan`

5. ❎ **PUT** -> `/admin/update-clan/{clanId}`

6. ❎ **DELETE** -> `/admin/delete-clan/{clanId}`

7. ❎ **POST** -> `/admin/create-war`

8. ❎ **PUT** -> `/admin/update-war/{warId}`

9. ❎ **DELETE** -> `/admin/delete-war/{warId}`

10. ❎ **POST** -> `/admin/create-region`

11. ❎ **PUT** -> `/admin/update-region/{regionId}`

12. ❎ **DELETE** -> `/admin/delete-region/{regionId}`

13. ❎ **POST** -> `/admin/create-challenge`

14. ❎ **PUT** -> `/admin/update-challenge/{challengeId}`

15. ❎ **DELETE** -> `/admin/delete-challenge/{challengeId}`

## Players

1. ❎ **GET** ->  `/players/best-in-war/{warId}`

2. ❎ **GET** ->  `/players/clans-can-join/{playerId}`

3. ❎ **GET** ->  `/players/`

4. ❎ **GET** ->  `/players/{playerId}`

## Cards

1. ❎ **GET** ->  `/cards/most-donated-in-region/{regionId}`

2. ❎ **GET** ->  `/cards/most-popular-in-clan/{clanId}`

3. ❎ **GET** ->  `/cards/`

4. ❎ **GET** ->  `/cards/{cardId}`

## Clans

1. ❎ **GET** ->  `/clans/`

2. ❎ **GET** ->  `/clans/{clanId}`

## Wars

1. ❎ **GET** ->  `/wars/`

2. ❎ **GET** ->  `/wars/{warId}`

## Regions

1. ❎ **GET** ->  `/regions/best-clan/{regionId}`

2. ❎ **GET** ->  `/regions/`

3. ❎ **GET** ->  `/regions/{regionId}`

## Challenges

1. ❎ **GET** ->  `/challenges/completed-by-some-player`

2. ❎ **GET** ->  `/challenges/`

3. ❎ **GET** ->  `/challenges/{challengeId}`
