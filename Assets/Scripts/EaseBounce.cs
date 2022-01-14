public static class EaseBounce {
    public static float EaseInBounce(float x) {
        return 1 - EaseOutBounce(1 - x);
    }

    public static float EaseOutBounce(float x){
        var n1 = 7.5625f;
        var d1 = 2.75f;

        if (x < 1 / d1) 
            return n1 * x * x;
        if (x < 2f / d1) 
            return n1 * (x -= 1.5f / d1) * x + 0.75f;
        if (x < 2.5f / d1) 
            return n1 * (x -= 2.25f / d1) * x + 0.9375f;
    
        return n1 * (x -= 2.625f / d1) * x + 0.984375f;
    }
}
