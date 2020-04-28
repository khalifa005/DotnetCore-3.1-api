﻿namespace TweetBook.Contract.V1
{
    public static class ApiRoutes
    {
        public const string Route = "api";
        public const string Version = "v1";
        public const string Base = Route+"/"+Version;
        public static class Posts
        {
            public const string GetAll = Base+"/posts";
        }
    }
}
