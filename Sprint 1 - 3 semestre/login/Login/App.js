import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View, TextInput, Image, Touchable } from 'react-native';
import { TouchableOpacity } from 'react-native-web';

export default function App() {
  return (

    <View style={styles.container}>


      <Image style={styles.image} source={require('./src/assets/img/Slime_Rosa.webp')} />


      <Text style={fonte.Text}>Login</Text>
      <StatusBar style="auto" />

      <TextInput
        style={styles.input}
        placeholder='Email'
      />

      <TextInput
        style={styles.input}
        placeholder='Senha'
      />
      <TouchableOpacity>

      <text style={styles.esqueceu}>Esqueceu a senha?</text>
      </TouchableOpacity>

      <TouchableOpacity style = {styles.logarButton}>
        <Text style = {styles.logarText}>Logar</Text>
    </TouchableOpacity>


    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#add8e6',
    alignItems: 'center',
    justifyContent: 'center',
  },
  input: {
    width: '70%',
    height: 40,
    borderWidth: 1,
    padding: 10,
    marginTop: 10,
    marginBottom: 10,
    borderRadius: 10,
    backgroundColor: 'white',
    borderColor: 'white'
  },
  image: {
    width: 100,
    height: 100,
    marginBottom: 30,
  },
  logarButton: {
    color: 'white',
    fontWeight: 500,
    marginTop: 40,
    borderWidth: 1,
    padding: 10,
    borderRadius: 13,
    borderColor: '#fff',
    backgroundColor: '#fff'
  },
  logarText: {
    color: 'black',
    justifyContent: 'center',
    alignContent: 'center'
  },
  esqueceu: {
    marginTop: 8,
    fontSize: 12,
  }
});

const fonte = StyleSheet.create({
  Text: {
    fontSize: 20,
    marginBottom: 20,
    marginTop: 100,
  }
})
