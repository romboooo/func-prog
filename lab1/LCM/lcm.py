def gcd(a,b):
    while b != 0:
        a,b = b, a % b
    return a

def lcm(a,b):
    if a == 0 or b == 0:
        return 0
    return (a * b) // gcd(a,b)

result = 1
for i in range(1,21):
    result = lcm(result,i)

print(result)