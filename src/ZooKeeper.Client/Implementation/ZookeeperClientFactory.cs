using System.Collections.Concurrent;

namespace ZooKeeper.Client.Implementation
{
    public class ZookeeperClientFactory : IZookeeperClientFactory
    {
        private readonly static ConcurrentDictionary<string, ZookeeperClient> _cacheDic = new ConcurrentDictionary<string, ZookeeperClient>();

        public ZookeeperClient Get(ZookeeperRegistryConfiguration config)
        {
            string key = $"{config.Host}:{config.Port}";
            return _cacheDic.GetOrAdd(key, k => new ZookeeperClient(key));
        }
    }
}