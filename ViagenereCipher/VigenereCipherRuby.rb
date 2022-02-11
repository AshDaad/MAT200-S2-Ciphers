def vigenère(msg, key, op = :+)
    key = key.chars.cycle.take msg.size
    msg.chars.zip(key).map do |pair|
      (pair.map(&:ord).reduce(op) % 26 + 65).chr
    end.join
  end