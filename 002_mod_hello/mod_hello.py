"""
   Hello World in the style of FizzBuzz
"""

for i in range(1, 61):
    if i % 5 == 0:
        if i % 3 == 0:
            print("HelloWorld")
        else:
            print("World")
    elif i % 3 == 0:
        print("Hello")
    else:
        print(i)

        
