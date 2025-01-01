using System;
using System.Security.Cryptography;

namespace Japper.Options;

public class JapperOptions
{
    private bool _useRedis {get; set;} = false;
    private HashAlgorithmName _hashAlgorithmName {get; set;} = HashAlgorithmName.SHA256;
    private bool _disableCaching {get; set;} = false;

    //TODO: Make validations for options
    public JapperOptions(bool UseRedis = true, HashAlgorithmName? HashAlgorithm = null, bool DisableCaching = false){
        _useRedis = UseRedis;

        if(HashAlgorithm is not null){
            _hashAlgorithmName = HashAlgorithm.Value;
        } else {
            _hashAlgorithmName = HashAlgorithmName.SHA256;
        }

        _disableCaching = DisableCaching;
    }
    public JapperOptions UseSHA512(){
        _hashAlgorithmName = HashAlgorithmName.SHA512;
        return this;
    }
    public JapperOptions UseRedis(){
        _useRedis = true;
        return this;
    }

    public JapperOptions DisableCaching(){
        _disableCaching = true;
        return this;
    }
}
