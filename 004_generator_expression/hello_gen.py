"""
Print Hello World using a generator expression
"""

def hello():
    """returns 'Hello World' using a generator expression"""

    letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
  
    return [ H+e+l+l+o+space+W+o+r+l+d 
                        for H in letters if H == 'H'
                        for e in letters if e == 'e'
                        for l in letters if l == 'l'
                        for o in letters if o == 'o'
                        for space in letters if space == ' '
                        for W in letters if W == 'W'
                        for r in letters if r == 'r'
                        for d in letters if d == 'd'
    
    ]

print(hello())