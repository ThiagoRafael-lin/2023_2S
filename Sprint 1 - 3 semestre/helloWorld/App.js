import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View, TextInput, Image, Button, Touchable } from 'react-native';
import { TouchableOpacity } from 'react-native-web';

export default function App() {
  return (
    <View style={styles.container}>


      <Text style={fonte.Text}>Hello, World !!</Text>

      <TextInput
        style={styles.input}
        defaultValue='exemplo de input'
      />

      <TouchableOpacity style={styles.Button}>
        <text style={styles.textbutton}>Aperte Aqui</text>
      </TouchableOpacity>

      {/* <Button
      title='Aperte Aqui'
      style = {styles.Button}
      /> */}

      {/*
outra maneira de importar imagem

<Image
source={{
  uri: "url da imagem"
}}
/>*/}

      <Image style={styles.image} source={require('./src/assets/img/Slime_Rosa.webp')} />

      <StatusBar style="auto" />


    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
  input: {
    width: '90%',
    height: 40,
    borderWidth: 1,
    padding: 10,
    marginTop: 10,
    marginBottom: 10

  },
  image: {
    width: 100,
    height: 100
  },
  Button: {
    width: 90,
    height: 40,
    borderColor: 'black',
    borderWidth: 1,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: 'black',
    borderRadius: 10
  },
  textbutton: {
    color: '#fff',
    fontWeight: 500,

  }
});

const fonte = StyleSheet.create({
  Text: {
    fontSize: 50,
  }
})
