namespace Entity.Movement
{
    public class JobBatchSize
    {
        private readonly int _totalCount;

        public JobBatchSize(int totalCount)
        {
            _totalCount = totalCount;
        }

        public int GetOptimalBatchSize()
        {
            if (_totalCount <= 10) return 2;      
            if (_totalCount <= 20) return 3;      
            if (_totalCount <= 35) return 5;     
            if (_totalCount <= 50) return 8;    
            if (_totalCount <= 100) return 12;  
            if (_totalCount <= 250) return 24;    
            if (_totalCount <= 500) return 48;    
            if (_totalCount <= 1000) return 64;   
            return 96;                            
        }
    }
}