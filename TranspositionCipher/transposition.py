def decrypt(message, password):
    decrypted = ''
    for i in range(0, len(message)):
        letter = ord(message[i]) - ord(password[i%len(password)]) + 65
        if letter < 65:
            letter += 26
        decrypted += chr(letter)
    return decrypted