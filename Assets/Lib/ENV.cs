﻿using System.Collections;
using System.Collections.Generic;

public static class ENV  { 

// MISC
public static string 
API_URL = "http://minha-arvore.herokuapp.com",
GOOGLE_MAPS_KEY = "AIzaSyACtmxnxRymLJh3rhS0wkAaFsFgDNzXLDk",
GOOGLE_MAPS_URL = "https://maps.googleapis.com/maps/api/staticmap?center=PLACE&zoom=15&size=600x300&maptype=terrain&markers=color:green%7CPLACE";

// ROUTES
public static string
USERS_ROUTE = "users",
PLANTS_ROUTE = "trees",
PLANTS_REQUEST_ROUTE= "tree_requests",
PLANTS_TYPES_ROUTE= "tree_types",
POSTS_ROUTE = "posts",
EVENTS_ROUTE = "appointment",
EVENTS_REQUESTS_ROUTE = "appointment_requests",
GROUPS_ROUTE = "groups",
GROUP_MEMBERS_ROUTE = "group_members";

// ACTIONS
public static string
AUTH_ACTION = "auth",
EMAIL_ACTION = "email",
GROUPS_ACTION = "groups",
REGISTER_ACTION = "register",
UPDATE_ACTION = "update",
REMOVE_ACTION = "remove",
QUERY_ACTION = "query/fields?";

}
