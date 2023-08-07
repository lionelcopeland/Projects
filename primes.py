# Online Python compiler (interpreter) to run Python online.
# Write Python 3 code in this online editor and run it.


nums = range(1,10000)

def is_prime (num):
    for x in range(2, num):
        if (num%x) == 0:
            return False
        return True
        
primes = list(filter(is_prime, nums))

print(primes)

''' NEXT PROGRAM '''


names = [
    'Daniel',
    'Mike',
    'William'
    
 ]
 
 '''List Comprehension
 
 length = [len(name) for name in names] '''
 
 #Dictionary Comprehension
 length = {name:len(name) for name in names}
 
 print(length)
 
 
 ''' NEXT PROGRAM '''
 
 from functools import lru_cache
 
 @lru_cache # this is called a decorator - lru = "least recently used"
 def increment(num):
    print('Running 1000 lines of code')
    return num+1
    
   print(increment(1))
   print(increment(2))
   print(increment(3))
   print(increment(1))
   
   #this prevents repeats of printing multiple lines of code
   # if with the lru_cache you the repeated line will just show the previous printout.
   
   ''' NEXT PROGRAM '''
   
  inventory = [
    'Crimson Sword',
    'Great Helm',
    'Leather Boots'
    
   ]
   
   
  chest = [
    'Health Potion',
    'Mana Potion',
    'Map of Riches'
   ]
   
   #this for loop will get the job done but inventory.extend will be a better method.
   '''for item in chest:
    inventory.append(item)
    
   print(inventory)'''
   
   inventory.extend(chest)
   
   print(inventory)
   
   ''' PYTHON PROJECTS TO WORK ON'''
   
 '''
    File Organizer
    Unit Converter
    QR Code Generator
 '''
 
 
    ''' Concepts '''
    
 '''
    Enumerate
    Pipe operators
    Use sets instead of lists
    Counters
    String.join
    
 
 '''
 
 ''' NEXT PROGRAM '''
 
 num1 = 1_000_000_000
 num2 = 2_000
 
 ans = num1*num2
 print(f'{ans:_}')
 
 #long integer
 
 ''' NEXT PROGRAM '''
 
 #logic
 
 i = 0
 while i <3:
    print(i)
    i += 1
else:
    print(0)
 
 # Choose correct output
 
 # A: 0 1 2 3 0 
 # B: 0 1 2 0
 # C: 0 1 2
 # D: Error
 
 
 ''' NEXT PROGRAM '''
 
 #FUNCTIONS VS. Lambda FUNCTIONS
 
 # add 1 + 2
 
 # regular function
 
 def add (x,y):
    return x+y
 print(add(1,2))
 
 #lambda function
  
 print(lambda x,y: x+y)(1,2))
 
 
 ''' NEXT PROGRAM '''
 
 import time
 from itertools import cycle
 lights = [
    ('Green', 2),
    ('Yellow', 0.5),
    ('Red', 2)
 ]
 
''' i = 0 
 while True:
    c,s = lights[i]
    print(c)
    time.sleep(s)
    if i == len(lights)-1:
        i = 0
    else:
        i += 1 '''
        
 # better solution
 
 colors = cycle(lights)
 while True:
    c,s = next(colors)
    print(c)
    time.sleep(s)
    
 # no need for index in this solution
 
 ''' NEXT PROGRAM '''
 
 links = [
    "www.b001.io",
    "www.youtube.com",
    "www.google.com",
    "www.wikipedia.org"
]

'''for link in links:
    print(link.lstrip("www."))'''
#only deletes characters

for link in links:
    print(link.removeprefix("www."))
    
#Removes prefixes

''' NEXT PROGRAM '''


