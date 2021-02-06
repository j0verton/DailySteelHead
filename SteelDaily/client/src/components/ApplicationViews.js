import React, { useContext } from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import { UserProfileContext } from "../providers/UserProfileProvider";
import Login from "../pages/Login";
import Register from "../pages/Register";
import NTIGame from "../pages/NTIGame";
import NTIFBGame from "../pages/NTIFBGame";
import UnisonFinderGame from "../pages/UnisonFinderGame";

const ApplicationViews = () => {
  const { isLoggedIn, isAdmin } = useContext(UserProfileContext);

  return (
    <Switch>
      <Route path="/NTIgame">
        <NTIGame />
      </Route>
      <Route path="/NTIFretboardGame">
        <NTIFBGame />
      </Route>
      <Route path="/UnisonFinderGame">
        <UnisonFinderGame />
      </Route>
      {/* <Route path="/" exact>
        {isLoggedIn ? <HomePageManager /> : <Redirect to="/login" />}
      </Route>
      <Route path="/explore">
        {isLoggedIn ? <Explore /> : <Redirect to="/login" />}
      </Route> */}
      {/* <Route path="/approval">
        {isLoggedIn ? (
          isAdmin() ? (
            <Approval />
          ) : (
              <Redirect to="/" />
            )
        ) : (
            <Redirect to="/login" />
          )}
      </Route> */}
      {/* <Route path="/myprofile">
        {isLoggedIn ? <ProfileView /> : <Redirect to="/login" />}
      </Route> */}
      {/* <Route path="/mypost">
        {isLoggedIn ? <MyPostList /> : <Redirect to="/login" />}
      </Route> */}
      {/* <Route path="/post/edit/:id">
        {isLoggedIn ? <PostEdit /> : <Redirect to="/login" />}
      </Route>
      <Route path="/create/post">
        {isLoggedIn ? <PostForm /> : <Redirect to="/login" />}
      </Route>
      <Route path="/subscription">
        {isLoggedIn ? <Subscription /> : <Redirect to="/login" />}
      </Route>
      <Route path="/post/:postId">
        {isLoggedIn ? <PostDetails /> : <Redirect to="/login" />}
      </Route> */}
      {/* <Route path="/categories">
        {isLoggedIn ? (
          isAdmin() ? (
            <CategoryManager />
          ) : (
              <Redirect to="/" />
            )
        ) : (
            <Redirect to="/login" />
          )}
      </Route> */}
      {/* <Route path="/comment/:postId">
        {isLoggedIn ? <CommentForm /> : <Redirect to="/login" />}
      </Route>
      <Route path="/Tags">
        {isLoggedIn ? (
          isAdmin() ? (
            <Tags />
          ) : (
              <Redirect to="/" />
            )
        ) : (
            <Redirect to="/login" />
          )}
      </Route>
      <Route path="/Create/Tags">
        {isLoggedIn ? <TagForm /> : <Redirect to="/login" />}
      </Route>
      <Route path="/profiles">
        {isLoggedIn ? (
          isAdmin() ? (
            <ProfileManager />
          ) : (
              <Redirect to="/" />
            )
        ) : (
            <Redirect to="/login" />
          )}
      </Route> */}
      <Route path="/login">
        <Login />
      </Route>
      <Route path="/register">
        <Register />
      </Route>
    </Switch>
  );
};

export default ApplicationViews;
