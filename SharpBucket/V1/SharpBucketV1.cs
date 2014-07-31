﻿using SharpBucket.V1.EndPoints;

namespace SharpBucket.V1{
    public sealed class SharpBucketV1 : SharpBucket{
        public SharpBucketV1(){
            _baseUrl = "https://bitbucket.org/api/1.0/";
        }

        public UserEndPointV1 User(){
            return new UserEndPointV1(this);
        }

        public RepositoriesEndPointV1 Repositories(string accountName, string repository){
            return new RepositoriesEndPointV1(accountName, repository, this);
        }

        public UsersEndpointV1 Users(string accountName){
            return new UsersEndpointV1(accountName, this);
        }
    }
}