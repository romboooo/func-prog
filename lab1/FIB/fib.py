def find_first_fibonacci_with_digits(digit_count):
    if digit_count <= 1:
        return 1
    
    a, b = 1, 1
    index = 2
    
    while len(str(b)) < digit_count:
        a, b = b, a + b
        index += 1
    print(index)
    return index



find_first_fibonacci_with_digits(1000)